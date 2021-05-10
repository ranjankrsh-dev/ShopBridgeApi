using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBridgeApi.Models
{
    public class Inventory
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public double ItemPrice { get; set; }
        public string ItemCategory { get; set; }
        public string ImageFileName { get; set; }
        public string ImageFileExtension { get; set; }
        public string ImageFilePath { get; set; }
        public int ImageFileSize { get; set; }
        public bool IsItemInStock { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
}


