using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao.Models
{
    public class GitHubApi
    {
        public List<GitHubApiItem> items { get; set; }
    }

    [Table("GitHubApiItem")]
    public class GitHubApiItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Column("name", TypeName = "varchar"), MaxLength(50)]
        public string name { get; set; }

        [Column("full_name", TypeName = "varchar"), MaxLength(200)]
        public string full_name { get; set; }

        [Column("description", TypeName = "varchar"), MaxLength(1000)]
        public string description { get; set; }

        [Column("stargazers_count")]
        public int stargazers_count { get; set; }

        [Column("clone_url"), MaxLength(500)]
        public string clone_url { get; set; }

        [Column("homepage"), MaxLength(500)]
        public string homepage { get; set; }

        public int owner_id { get; set; }

        [ForeignKey("owner_id")]
        public GitHubApiOwner owner { get; set; }
    }

    [Table("GitHubApiOwner")]
    public class GitHubApiOwner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Column("login", TypeName = "varchar"), MaxLength(50)]
        public string login { get; set; }
    }
}