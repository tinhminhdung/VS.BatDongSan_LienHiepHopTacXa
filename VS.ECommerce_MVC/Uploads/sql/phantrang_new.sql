USE [VS.ECommerce_MVC_Global_2019]
GO
/****** Object:  StoredProcedure [dbo].[Category_News_List]    Script Date: 05/26/2019 14:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Category_News_List] 
(	
	@Nhom nvarchar(500),
	@lang nvarchar(50),
	@Status [tinyint],
	@PageIndex	[int],
	@TotalRecord[int]output,
	@Tongpage int
	
)
AS	
	DECLARE		@StartRecord	int
	DECLARE		@EndRecord	    int	
	SET @StartRecord = @PageIndex * @Tongpage
	SET @EndRecord = @StartRecord + @Tongpage + 1	
BEGIN TRANSACTION AT
	BEGIN 		
	WITH tmp_Product_Lists AS ( SELECT	ROW_NUMBER() OVER (ORDER BY Create_Date DESC) AS Row, inid,TangName,Title,Images,ImagesSmall,Brief,Create_Date
		FROM        News
		WHERE	 icid in  (select value from dbo.SplitString(@Nhom,',')) and  lang=@lang and  Status= @Status )			
				SELECT  *
				FROM     tmp_Product_Lists
				WHERE ( Row > @StartRecord AND Row < @EndRecord )
				SET @TotalRecord = (SELECT COUNT(*) FROM News WHERE  icid in  (select value from dbo.SplitString(@Nhom,',')) and  lang=@lang and  Status= @Status)	
	END
	IF(@@ERROR<>0)
		BEGIN
			ROLLBACK TRANSACTION AT
		END
	ELSE
		BEGIN
			COMMIT TRANSACTION  AT
		END
