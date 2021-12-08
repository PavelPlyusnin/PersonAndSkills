using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonAndSkills.Model
{
    public class Skill
    {
        public long SkillId { get; set; }
        public string Name { get; set; }
        [Range(0,10)]
        public byte Level { get; set; }
    }
}
