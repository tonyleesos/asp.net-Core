
namespace prjDI01.Models
{
    public class MemberList
    {
        public Member GetMember(string uid,string pwd) 
        {
            IList<Member> members = new List<Member>();
            members.Add(new Member { Uid = "jasper", Pwd = "123", RePwd="123", Name="李1", Role = "admin" });
            members.Add(new Member { Uid = "mary", Pwd = "123", RePwd = "123", Name = "李2", Role = "member" });
            members.Add(new Member { Uid = "andy", Pwd = "123", RePwd = "123", Name = "李3", Role = "member" });
            var member = members.Where(x => x.Uid == uid && x.Pwd == pwd).FirstOrDefault();
            return member;
        }
    }
}
