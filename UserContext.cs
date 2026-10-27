using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public sealed class UserContext
    {
        public string Name { get; }
        public UserRole Role { get; }
        public string RawInfo { get; }

        public UserContext(string name, UserRole role)
        {
            Name = string.Join(" ", (name ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Role = role;
        }

        public UserContext(string userInfo)
        {
            RawInfo = userInfo ?? "";
            int open = RawInfo.LastIndexOf('(');
            int close = RawInfo.LastIndexOf(')');

            string namePart = open >= 0 ? RawInfo.Substring(0, open) : RawInfo;
            string rolePart = (open >= 0 && close > open)
                ? RawInfo.Substring(open + 1, close - open - 1).Trim()
                : "Студент";

            Name = string.Join(" ", namePart.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            Role = rolePart switch
            {
                "Викладач" => UserRole.Professor,
                "Аспірант" => UserRole.Assistant,
                _ => UserRole.Student
            };
        }

        public override string ToString()
        {
            return $"{Name} ({Role.ToDisplayName()})";
        }
    }
}
