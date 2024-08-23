using Library_Managment_Project.Enum;

namespace Library_Managment_Project.Entities
{
    public class Member : User
    {
        public MemberShipType MemberShipType { get; set; }
    }
}
