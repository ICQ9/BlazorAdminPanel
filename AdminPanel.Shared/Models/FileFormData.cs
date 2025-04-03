using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Shared.Models
{
    public class FileFormData
    {
        public string? FileBase64 { get; set; }
        public int TemplateId { get; set; } = 0;
        public string? TemplateName { get; set; }
        public string? HelpLink { get; set; }
        public string? TemplateDescription { get; set; }
        public int Weight { get; set; }
        public int CreativeId { get; set; }
        public bool InView { get; set; } = true;
        public object? Attributes { get; set; }
        public object? FileInfo { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public bool Scale { get; set; } = false;
    }
}
