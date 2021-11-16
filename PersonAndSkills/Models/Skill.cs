using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonAndSkills.Model
{
    public class Skill
    {
        public long SkillId { get; set; }
        public string Name { get; set; }
        public byte Level { get; set; }
    }
}
