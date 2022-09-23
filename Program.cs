using ApiCsharp.Contexto;
using ApiCsharp.Models;
using ApiCsharp.Models.ModelDTO;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<Contexto>
    (option => option.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=ApiWebCsharp;User Id=postgres;Password=1234;"));

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();


app.MapPost("AdicionarUsuario", async (UsuarioDTO usuarioDto, Contexto contexto) =>
{
    Usuario usuario = new Usuario();

    usuario.NomeCompleto = usuarioDto.NomeCompleto;
    usuario.Idade = usuarioDto.Idade;
    usuario.Telefone = usuarioDto.Telefone;
    usuario.DataNascimento = usuarioDto.DataNascimento;

    var role = await contexto.Role.FirstOrDefaultAsync(p => p.Id == usuarioDto.IdRole);
    if (role != null)
    {
        usuario.Role = role;
        contexto.Usuario.Add(usuario);
        await contexto.SaveChangesAsync();
        return Results.Ok();
    }
    else
    {
        return Results.BadRequest();
    }


});


app.MapPost("AdicionarRole", async (RoleDTO roleDto, Contexto contexto) =>
{
    try
    {
        Role role = new Role();

        role.Nome = roleDto.Nome;
        role.Descricao = roleDto.Descricao;

        contexto.Role.Add(role);
        await contexto.SaveChangesAsync();
        return Results.Ok();

    }
    catch (Exception)
    {

        return Results.BadRequest();
    }

});


app.MapPost("AdicionarProduto", async (ProdutoDTO produtoDto, Contexto contexto) =>
{
    Produto produto = new Produto();
    produto.Nome = produtoDto.Nome;
    contexto.Produto.Add(produto);
    await contexto.SaveChangesAsync();
});

app.MapDelete("ExcluirProduto/{id}", async (int id, Contexto contexto) =>
{
    var produtoExcluir = await contexto.Produto.FirstOrDefaultAsync(p => p.Id == id);
    if (produtoExcluir != null)
    {
        contexto.Produto.Remove(produtoExcluir);
        await contexto.SaveChangesAsync();
        return Results.Ok();
    }
    else
    {
        return Results.BadRequest();
    }

});

app.MapGet("ListarProdutos", async (Contexto contexto) =>
{
    return await contexto.Produto.ToListAsync();

});

app.MapGet("ObterProduto/{id}", async (int id, Contexto contexto) =>
{
    return await contexto.Produto.FirstOrDefaultAsync(p => p.Id == id);

});

app.MapPut("AtualizarProduto/{id}", async (int id, Produto produto, Contexto contexto) =>
{
    var produtoEncontrado = await contexto.Produto.FirstOrDefaultAsync(p => p.Id == id);

    if (produtoEncontrado == null)
    {
        return Results.BadRequest();
    }
    produtoEncontrado.Nome = produto.Nome;
    contexto.Produto.Update(produtoEncontrado);
    await contexto.SaveChangesAsync();
    return Results.Ok();

});


app.UseSwaggerUI();
app.Run();
