using System;

namespace Atlanta.Domain
{
    public class Gods
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
    }
}
