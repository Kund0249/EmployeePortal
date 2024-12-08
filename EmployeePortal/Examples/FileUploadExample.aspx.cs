using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeePortal.Examples
{
    public partial class FileUploadExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            
            if (fileControl.HasFile)
            {
               
                //string serverFolder = "~/UploadFiles";
                string serverFolder = Server.MapPath("~/UploadFiles");
                string ext = Path.GetExtension(fileControl.FileName).ToLower();
                
                //string filePath = Path.Combine(serverFolder, fileControl.FileName); //serverFolder + "/" + fileControl.FileName;
                 int length =  fileControl.PostedFile.ContentLength;
                //1kb = 1024 bytes
                //1Mb = 1024 KB
                //1Mb = 2*1024*1024
                if(ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                {
                    if (length <= (2 * 1024 * 1024))
                    {
                        string guid = Guid.NewGuid().ToString();
                        string fileName = guid + ext;
                        string filePath = Path.Combine(serverFolder, fileName);
                        fileControl.SaveAs(filePath);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
                

            }
        }
    }
}