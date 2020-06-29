using Mighty;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppExampleMighty.Models
{
    [DatabaseTable("persons")]
    public class Person
    {
        [DatabaseColumn("id")]
        [DatabasePrimaryKey()]
        public int Id { get; set; }

        [Required()]
        [DatabaseColumn("name")]
        public string Name { get; set; }

        [Required()]
        [DatabaseColumn("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
