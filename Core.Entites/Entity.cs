using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites
{
    /// <summary>
    /// for creating system entites, the basic propertes and it's init for objects
    /// </summary>
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public Entity()
        {
            Id = new Guid();
            CreatedDate = DateTime.Now;
            
        }
    }
}
