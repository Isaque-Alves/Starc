﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Star;

namespace Star.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20191008113154_migrando-localhost")]
    partial class migrandolocalhost
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Star.Models.Cadastro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Cadastros");
                });

            modelBuilder.Entity("Star.Models.Componente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<int>("CadastroId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<bool>("Status");

                    b.Property<int>("TipoComponenteId");

                    b.HasKey("Id");

                    b.HasIndex("CadastroId");

                    b.HasIndex("TipoComponenteId");

                    b.ToTable("Componentes");
                });

            modelBuilder.Entity("Star.Models.ComponenteGrupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<int>("ComponenteId");

                    b.Property<int>("GrupoId");

                    b.HasKey("Id");

                    b.HasIndex("ComponenteId");

                    b.HasIndex("GrupoId");

                    b.ToTable("ComponenteGrupos");
                });

            modelBuilder.Entity("Star.Models.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.Property<bool>("Domingo");

                    b.Property<DateTime>("HorarioFinal");

                    b.Property<DateTime>("HorarioInicial");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<bool>("Quarta");

                    b.Property<bool>("Quinta");

                    b.Property<bool>("Sabado");

                    b.Property<bool>("Segunda");

                    b.Property<bool>("Sexta");

                    b.Property<bool>("Terca");

                    b.HasKey("Id");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("Star.Models.Registro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ComponenteId");

                    b.Property<DateTime>("DataHora");

                    b.Property<bool>("Status");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("ComponenteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Registros");
                });

            modelBuilder.Entity("Star.Models.TipoComponente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("TipoComponentes");
                });

            modelBuilder.Entity("Star.Models.TipoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("TipoUsuarios");
                });

            modelBuilder.Entity("Star.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CadastroId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Senha")
                        .IsRequired();

                    b.Property<bool>("Status");

                    b.Property<int>("TipoUsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("CadastroId");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Star.Models.Componente", b =>
                {
                    b.HasOne("Star.Models.Cadastro", "Cadastro")
                        .WithMany("Componentes")
                        .HasForeignKey("CadastroId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Star.Models.TipoComponente", "TipoComponente")
                        .WithMany("Componentes")
                        .HasForeignKey("TipoComponenteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Star.Models.ComponenteGrupo", b =>
                {
                    b.HasOne("Star.Models.Componente", "Componente")
                        .WithMany()
                        .HasForeignKey("ComponenteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Star.Models.Grupo", "Grupo")
                        .WithMany("ComponenteGrupos")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Star.Models.Registro", b =>
                {
                    b.HasOne("Star.Models.Componente", "Componente")
                        .WithMany("Registros")
                        .HasForeignKey("ComponenteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Star.Models.Usuario", "Usuario")
                        .WithMany("Registros")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Star.Models.Usuario", b =>
                {
                    b.HasOne("Star.Models.Cadastro", "Cadastro")
                        .WithMany("Usuarios")
                        .HasForeignKey("CadastroId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Star.Models.TipoUsuario", "TipoUsuario")
                        .WithMany("Usuarios")
                        .HasForeignKey("TipoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}