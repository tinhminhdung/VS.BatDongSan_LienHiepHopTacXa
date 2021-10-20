using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace MoreAll
{
    public class RegularExpressions
    {
        // 1. Hàm kiểm tra tính hợp lệ của email.
        public static bool IsValidEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"^.+\@(\[?)[a-zA-Z0-9\-\.]+\.([a-zA-Z]{2,3}|[0-9]{1,3})(\]?)$");
        }

        //2. Hàm kiểm tra xem đường dẫn địa chỉ web có hợp lệ hay không
        public static bool IsValidURL(string url)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(url, @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&%\$#\=~])*[^\.\,\)\(\s]$");
        }

        //3.Và hàm sau dùng để kiểm tra một chuỗi có dạng là số interger hay không.
        public static bool phone(string phone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^(?:\+?1\s*(?:[.-]\s*)?)?(?:\(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?([2-9a-z]1[02-9a-z]|[2-9a-z][02-9a-z]1|[2-9a-z][02-9a-z]{2})([0-9a-z]{4})([0-9a-z]*)$");
        }

        public static bool IsValidInt(string val)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(val, @"^[1-9]\d*\.?[0]*$");
        }
        public static bool Password(string pass)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(pass, @"^(?=(.*[a-z]){1,})(?=(.*[A-Z]){1,})(?=(.*[0-9]){1,})(?=(.*[!@#$%^&*()\-__+.]){1,}).{8,}$");
        }

        //[a-z]){1,} --> Số 1 là: chỉ cần 1 ký tự chữ thường từ a đến z là dc
        //[A-Z]){1,}-->  Số 1 là: chỉ cần 1 ký tự chữ HOA từ a đến z là dc
        //[0-9]){5,} -->  Số 1 là: Phải có 5  số từ 0 đến 9 là dc
        // VD: Ab12547 

        //if (!Password("Abc123456^") == true)
        //    {
        //        Response.Write("Mật khẩu bao gồm : 8 ký tự bao gồm 1 chữ cái viết hoa, 1 ký tự đặc biệt, ký tự chữ và số");
        //    }
        //    else
        //    {
        //        Response.Write("OK");
        //    }

        // ví dụ: https://regexr.com/3fhr4
        public static bool IsIpV4Address(string str)//chek kiểm tra địa chỉ IP ví dụ:
        {
            string[] arr = str.Split('.');
            if (arr.Length != 4)
            {
                return false;
            }
            foreach (string sub in arr)
            {
                try
                {
                    int test = int.Parse(sub);
                    if (test < 0 || test > 255) //nếu sub có nhiều chữ số 0 ở trước, khi convert qua số sẽ bị mất các số 0 ở đằng trước 
                    {
                        return false;
                    }
                    if (test.ToString().Length != sub.Length)
                    {
                        return false;// chứng tỏ sub có chứa các số 0 thừa ở đằng trước -> không hợp lệ.  
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;// vượt qua đc hết đống thử thách này thì chắc chắn là địa chỉ Ip V4 rùi ^^!    
        }
    }
}