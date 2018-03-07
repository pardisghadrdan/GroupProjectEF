using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectTimer.Models.Entities
{
    public partial class ProjectTimerContext : DbContext
    {
        public ProjectTimerContext(DbContextOptions<ProjectTimerContext> options) : base(options)
        {
        }
    }
}
