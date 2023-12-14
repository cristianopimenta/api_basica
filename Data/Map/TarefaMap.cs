using Microsoft.EntityFrameworkCore;
using OtimizeLaudoPredial.Models;

namespace OtimizeLaudoPredial.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TarefaModel> builder)
        {
           builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(1000);
        }
    }
}
