using System;
using System.Collections.Generic;

public class Venda
  {
    private int id;
    private DateTime data;
    private bool carrinho;
    private Cliente cliente;
    private string comentario;
    private int clienteId;
  
    private List<VendaLivro> livros = new List<VendaLivro>();

    public int Id { get => id; set => id = value; }
    public DateTime Data { get => data; set => data = value; }
    public bool Carrinho { get => carrinho; set => carrinho = value; }
    public string Comentario { get => comentario; set => comentario = value; }
    public int ClienteId { get => clienteId; set => clienteId = value; }
    public List<VendaLivro> Livros { get => livros; set => livros = value; }
  public Venda() { }
    
    public Venda(DateTime data, Cliente cliente){
      this.data = data;
      this.carrinho = true;
      this.cliente = cliente;
      this.clienteId = cliente.Id;
    }

    public void SetId(int id)
    {
        this.id = id;
    }

    public void SetData(DateTime data)
    {
        this.data = data;
    }

    public void SetCarrinho(bool carrinho)
    {
        this.carrinho = carrinho;
    }

    public void SetCliente(Cliente cliente)
    {
        this.cliente = cliente;
        this.clienteId = cliente.Id;
    }

    public void SetComentario(string comentario){
        this.comentario = comentario;
    }

    public int GetId()
    {
        return id;
    }

    public DateTime GetData()
    {
        return data;
    }

    public bool GetCarrinho()
    {
        return carrinho;
    }

    public Cliente GetCliente()
    {
        return cliente;
    }

    public string GetComentario(){
        return comentario;
    }

    public override string ToString()
    {
        if(carrinho){
          return "Compra: " + id + " - " + data.ToString("dd/MM/yyyy") + " - Cliente: " + cliente.Nome + " - carrinho";
        }
        else{
          return "Compra: " + id + " - " + data.ToString("dd/MM/yyyy") + " - Cliente: " + cliente.Nome;
        }
    }

    private VendaLivro LivroListar(Livro x){
      foreach(VendaLivro vl in livros){
        if(vl.GetLivro() == x){
          return vl;
        }
      }
       return null;
    }

    public List<VendaLivro> LivroListar(){
      return livros;
    }

    public void LivroInserir(int qtd, Livro l){
      VendaLivro livro = LivroListar(l);
      if(livro == null){
        livro = new VendaLivro(qtd, l);
        livros.Add(livro);
      }
      else{
        livro.SetQtd(livro.GetQtd() + qtd);
      }
    }

    public void LivroExcluir(){
      livros.Clear();
    }
}
// Sempre insere mas quando remove, remove todos.