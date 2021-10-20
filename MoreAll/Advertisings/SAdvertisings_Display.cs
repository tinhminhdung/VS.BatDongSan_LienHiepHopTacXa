using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoreAll;
using Services;
using System.Text.RegularExpressions;

namespace Advertisings
{
    public class Ad_vertisings
    {
       



        public static string QuangCao(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.Name_Text("select * from Advertisings where lang='" + MoreAll.MoreAll.Language + "' and value=" + ID + "  and Status=1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    string Text = "";
                    #endregion
                    
                    strb += "<aside id=\"media_image-5\" class=\"widget widget_media_image\">";
                    strb += ("<a target=" + Opentype + " href='" + Path + "'><img alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a>");
                    strb += "</aside>";
                }
            }
            return strb.ToString();
        }


        public static string QuangcaoDuoitintuctrangchu(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.Name_Text("select * from Advertisings where lang='" + MoreAll.MoreAll.Language + "' and value=" + ID + "  and Status=1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    string Text = "";
                    #endregion

                    strb += "<div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12 dear_title\">";
                    strb += "<div class=\"img1\">";
                    strb += ("<a target=" + Opentype + " href='" + Path + "'><img    alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a>");
                    strb += "</div>";
                    strb += "</div>";
                }
            }
            return strb.ToString();
        }
        public static string NhomSlideDuoiBanner(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.Name_Text("select * from Advertisings where lang='" + MoreAll.MoreAll.Language + "' and value=" + ID + "  and Status=1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    string Text = "";
                    #endregion

                    strb += ("<div class=\"cate_item\">");
                    strb += ("<div class=\"thumb_ img1\">");
                    strb += ("<a class=\"thumb_s\" target=" + Opentype + " href='" + Path + "'><img    alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a>");
                    strb += ("</div>");
                    strb += ("<h4 class=\"title_cate_\"><a class=\"thumb_s\" target=" + Opentype + " href='" + Path + "'>" + Name + "</a></h4>");
                    strb += ("</div>");
                }
            }
            return strb.ToString();
        }


        public static string TheoNhom(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.Name_Text("select * from Advertisings where lang='" + MoreAll.MoreAll.Language + "' and value=" + ID + " and Text=1 and Status=1");
            if (dt.Count > 0)
            {
                strb += "<section class=\"awe-section-3\">";
                strb += "<section class=\"section_two_banner\">";
                strb += "<div class=\"container\">";
                strb += "<div class=\"row\">";
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    string Text = "";
                    #endregion

                    if (dt.Count == 1)
                    {
                        strb += "<div class=\"col-lg-12 col-md-12 col-sm-12 col-xs-12 dear_title\">";
                        strb += "<div class=\"img1\">";
                        strb += ("<a target=" + Opentype + " href='" + Path + "'><img    alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a>");
                        strb += "</div>";
                        strb += "</div>";
                    }
                    else
                    {
                        strb += "<div class=\"col-lg-6 col-md-6 col-sm-6 col-xs-12 dear_title\">";
                        strb += "<div class=\"img1\">";
                        strb += ("<a target=" + Opentype + " href='" + Path + "'><img    alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a>");
                        strb += "</div>";
                        strb += "</div>";
                    }


                }
                strb += "</div>";
                strb += "</div>";
                strb += "</section>";
                strb += "</section>";
            }
            return strb.ToString();
        }

        public static string Showykienkhachhang(string ID)
        {

            string str = "";
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    #endregion
                    strb += (" <div class=\"item clearfix\">");
                    strb += (" <div class=\"thumbnail\">");
                    strb += ("<a target=" + Opentype + " href='" + Path + "'><img class=\"image wp-image-6172  attachment-full size-full\"   alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a>");
                    strb += (" </div>");
                    strb += ("<p class=\"uname\">" + Name + "</p>");
                    strb += (" <p class=\"ucomment text-justify\">" + Contents + "</p>");
                    strb += (" </div>");

                    if ((i + 1) % 3 == 0)
                    {
                        strb = "<div class=\"testimonial\">" + strb + "</div>";
                        str += strb.ToString();
                        strb = "";
                    }
                    else if (i == (dt.Count - 1))
                    {
                        strb = "<div class=\"testimonial\">" + strb + "</div>";
                        str += strb.ToString();
                    }
                }
            }
            return str.ToString();
        }
        public static string Contents(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    #endregion
                    #region Type
                    strb += Contents;
                    #endregion
                }
            }
            return strb.ToString();
        }
        public static string Advertisings_A_Images(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    #endregion
                    strb += ("<a target=" + Opentype + " href='" + Path + "'><img   alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a>");
                }
            }
            return strb.ToString();
        }

        public static string Advertisings(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    string Text = "";
                    #endregion
                    #region Type
                    if (dt[i].Text.ToString().Equals("1"))
                    {
                        strb += Contents;
                    }
                    if (Type.Equals("0"))//Text
                    {
                        strb += Contents;
                    }
                    else if (Type.Equals("1"))//Image
                    {
                        if (img.Length > 0)
                        {
                            strb += ("<a target=" + Opentype + " href='" + Path + "'><img  alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a><div style=' clear:both' class='quangcao'>" + Contents + "</div>");
                        }
                    }
                    else if (Type.Equals("2"))//VIDeo Youtube
                    {
                        strb += _Youtube(Youtube, Width, Height) + "<div style=' clear:both'  class='quangcao'>" + Contents + "</div>";
                    }
                    else if (Type.Equals("3"))//Flash
                    {
                        if (img.Length > 0)
                        {
                            strb += ("<embed style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    align='mIDdle'  quality='high' wmode='transparent' allowscriptaccess='always' flashvars='alink1=" + Path + "&amp;atar1=_blank' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='" + img + "'><div style=' clear:both'  class='quangcao'>" + Contents + "</div>");
                        }
                    }
                    #endregion
                }
            }
            return strb.ToString();
        }
        public static string Advertisings_LI(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    string Text = "";
                    #endregion
                    #region Type
                    if (dt[i].Text.ToString().Equals("1"))
                    {
                        strb += Contents;
                    }
                    if (Type.Equals("0"))//Text
                    {
                        strb += Contents;
                    }
                    else if (Type.Equals("1"))//Image
                    {
                        if (img.Length > 0)
                        {
                            strb += ("<li><a target=" + Opentype + " href='" + Path + "'><img  alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a></li>");
                        }
                    }
                    else if (Type.Equals("2"))//VIDeo Youtube
                    {
                        strb += _Youtube(Youtube, Width, Height) + Text;
                    }
                    else if (Type.Equals("3"))//Flash
                    {
                        if (img.Length > 0)
                        {
                            strb += ("<li><embed style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    align='mIDdle'  quality='high' wmode='transparent' allowscriptaccess='always' flashvars='alink1=" + Path + "&amp;atar1=_blank' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='" + img + "'></li>");
                        }
                    }
                    #endregion
                }
            }
            return strb.ToString();
        }


        public static string targets(string target)
        {
            if (target.Equals("0"))
            {
                return "_self";
            }
            return "_blank";
        }

        public static string _Youtube(string url, string Width, string Height)
        {
            #region Youtube
            string FormattedUrl = GetYouTubeID(url);
            string str = "<iframe style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "' src=\"https://www.youtube.com/embed/" + FormattedUrl.Replace("https://www.youtube.com/watch?v=", "") + "\" frameborder=\"0\" allow=\"accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>";
            return str.ToString();
            #endregion
        }
        public static string GetYouTubeID(string youTubeUrl)
        {
            //RegEx to Find YouTube ID
            Match regexMatch = Regex.Match(youTubeUrl, "^[^v]+v=(.{11}).*", RegexOptions.IgnoreCase);
            if (regexMatch.Success)
            {
                return "http://www.youtube.com/v/" + regexMatch.Groups[1].Value + "&hl=en&fs=1";
            }
            return youTubeUrl;
        }

        public static string label(string ID)
        {
            return Captionlanguage.GetLabel(ID, MoreAll.MoreAll.Language);
        }
    }
}

