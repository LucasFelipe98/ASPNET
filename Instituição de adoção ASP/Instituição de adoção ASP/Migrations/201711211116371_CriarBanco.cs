namespace Instituição_de_adoção_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animais",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        AnimalNome = c.String(nullable: false, maxLength: 50),
                        AnimalDescricao = c.String(nullable: false, maxLength: 500),
                        AnimalCor = c.String(nullable: false, maxLength: 50),
                        AnimalRaça = c.String(nullable: false, maxLength: 50),
                        AnimalImagem = c.String(),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        CategoriaNome = c.String(nullable: false, maxLength: 60),
                        CategoriaDescricao = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Instituições",
                c => new
                    {
                        InstituiçãoId = c.Int(nullable: false, identity: true),
                        InstituiçãoLogin = c.String(nullable: false, maxLength: 15),
                        InstituiçãoSenha = c.String(nullable: false, maxLength: 18),
                        InstituiçãoNome = c.String(nullable: false, maxLength: 50),
                        InstituiçãoTelefone = c.String(nullable: false, maxLength: 10),
                        InstituiçãoEmail = c.String(nullable: false, maxLength: 50),
                        InstituiçãoEndereco = c.String(nullable: false, maxLength: 50),
                        Animal_AnimalId = c.Int(),
                        Categoria_CategoriaId = c.Int(),
                        Usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.InstituiçãoId)
                .ForeignKey("dbo.Animais", t => t.Animal_AnimalId)
                .ForeignKey("dbo.Categorias", t => t.Categoria_CategoriaId)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UsuarioId)
                .Index(t => t.Animal_AnimalId)
                .Index(t => t.Categoria_CategoriaId)
                .Index(t => t.Usuario_UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Telefone = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 50),
                        Endereco = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instituições", "Usuario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Instituições", "Categoria_CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Instituições", "Animal_AnimalId", "dbo.Animais");
            DropForeignKey("dbo.Animais", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Instituições", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Instituições", new[] { "Categoria_CategoriaId" });
            DropIndex("dbo.Instituições", new[] { "Animal_AnimalId" });
            DropIndex("dbo.Animais", new[] { "CategoriaId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Instituições");
            DropTable("dbo.Categorias");
            DropTable("dbo.Animais");
        }
    }
}
