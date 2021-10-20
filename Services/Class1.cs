using System;
using System.Net;
using System.Xml.XPath;

namespace GeoCoderApiV3App1
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://maps.googleapis.com/maps/api/geocode/" +"xml?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&sensor=false";

            WebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                response = request.GetResponse();
                if (response != null)
                {
                    XPathDocument document = new XPathDocument(response.GetResponseStream());
                    XPathNavigator navigator = document.CreateNavigator();

                    // get response status
                    XPathNodeIterator statusIterator = navigator.Select("/GeocodeResponse/status");
                    while (statusIterator.MoveNext())
                    {
                        if (statusIterator.Current.Value != "OK")
                        {
                            Console.WriteLine("Error: response status = '" + statusIterator.Current.Value + "'");
                            return;
                        }
                    }

                    // get results
                    XPathNodeIterator resultIterator = navigator.Select("/GeocodeResponse/result");
                    while (resultIterator.MoveNext())
                    {
                        Console.WriteLine("Result: ");

                        XPathNodeIterator formattedAddressIterator = resultIterator.Current.Select("formatted_address");
                        while (formattedAddressIterator.MoveNext())
                        {
                            Console.WriteLine(" formatted_address: " + formattedAddressIterator.Current.Value);
                        }

                        XPathNodeIterator geometryIterator = resultIterator.Current.Select("geometry");
                        while (geometryIterator.MoveNext())
                        {
                            Console.WriteLine(" geometry: ");

                            XPathNodeIterator locationIterator = geometryIterator.Current.Select("location");
                            while (locationIterator.MoveNext())
                            {
                                Console.WriteLine("     location: ");

                                XPathNodeIterator latIterator = locationIterator.Current.Select("lat");
                                while (latIterator.MoveNext())
                                {
                                    Console.WriteLine("         lat: " + latIterator.Current.Value);
                                }

                                XPathNodeIterator lngIterator = locationIterator.Current.Select("lng");
                                while (lngIterator.MoveNext())
                                {
                                    Console.WriteLine("         lng: " + lngIterator.Current.Value);
                                }
                            }

                            XPathNodeIterator locationTypeIterator = geometryIterator.Current.Select("location_type");
                            while (locationTypeIterator.MoveNext())
                            {
                                Console.WriteLine("         location_type: " + locationTypeIterator.Current.Value);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Clean up");
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}