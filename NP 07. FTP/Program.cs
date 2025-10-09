using System.Net;

var ftpHostRoot = "ftp://eu-central-1.sftpcloud.io:21/";
List<string> filenames = [
    "abbas.txt",
    "Murad.txt",
    "istenilen ad.png",
    "tuqay.txt"
    ];
//UploadFTP(ftpHostRoot);
GetFTP(ftpHostRoot);

//filenames.ForEach(f =>
//{
//    DownloadFTP(ftpHostRoot, f);
//});
//DownloadFTP(ftpHostRoot);
void GetFTP(string url) {
    var request = WebRequest.Create(url) as FtpWebRequest;
    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
    request.Credentials =
       new NetworkCredential("35fbb7c60e0e4c3fbb71a0c9797512d4", "fIBBMg9ko8Rf8Hmn9g883eTHU9cPH9iU");

    var response = request.GetResponse() as FtpWebResponse;

    var stream = response!.GetResponseStream();
    var reader = new StreamReader(stream);
    var data = reader.ReadToEnd();
    Console.WriteLine(data);
}
void UploadFTP(string url) {
    var request = WebRequest.Create($"{url}statusCode.jpg") as FtpWebRequest;
    request.Method = WebRequestMethods.Ftp.UploadFile;
    request.Credentials =
        new NetworkCredential("908a9b8e4a4544458f383296e4fd0f5f", "ULHvMfRS14dahTTmWB9Vv9G2VPYyxpvC");

    var fileStream =
        new FileStream(@"C:\Users\zamanov\Downloads\1619338681039.jpg", FileMode.Open);
    var stream = request.GetRequestStream();
    fileStream.CopyTo(stream);

    stream.Close();
    fileStream.Close();
}
void DownloadFTP(string url, string fileName) {
    var request = WebRequest.Create($"{url}{fileName}") as FtpWebRequest;
    request.Method = WebRequestMethods.Ftp.DownloadFile;
    request.Credentials =
        new NetworkCredential("35fbb7c60e0e4c3fbb71a0c9797512d4", "fIBBMg9ko8Rf8Hmn9g883eTHU9cPH9iU");

    var fileStream 
        = new FileStream(@$"C:\Users\zamanov\Downloads\ftpDownload\{fileName}", FileMode.Create);

    var response = request.GetResponse() as FtpWebResponse;
    var stream = response.GetResponseStream();
    stream.CopyTo(fileStream);
    fileStream.Close();
    stream.Close();
}
