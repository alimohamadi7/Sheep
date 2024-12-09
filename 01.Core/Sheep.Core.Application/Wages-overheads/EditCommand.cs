using Sheep.Framework.Application.Utilities;
using Sheep.Framework.Application.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace Sheep.Core.Application.Wages_overheads
{
    public class EditCommand:CreateCommand
    {
        public Guid Id { get; set; }
        public DateTime StartLaste { get; set; }
        public DateTime EndLaste { get; set; }
    }
}
