

namespace Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<EmployeeEntity> Employees { get; private set; } = new List<EmployeeEntity>();
    }
}