using System;
using System.Collections.Generic;
using System.Text;

namespace Me.Dto.DataTransferObjects
{
    public class ReturnPhotoDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public string PublicId { get; set; }
    }
}
