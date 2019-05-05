using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Me.Dto.DataTransferObjects
{
    public class PhotoDto
    {
        public PhotoDto()
        {
            AddedDate = DateTime.Now;
        }

        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public string PublicId { get; set; }
    }
}
