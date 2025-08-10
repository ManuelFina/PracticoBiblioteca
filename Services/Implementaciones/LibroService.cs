using PracticoBiblioteca.Models;
using PracticoBiblioteca.Services.Interfaces;

namespace PracticoBiblioteca.Services.Implementaciones;

public class LibroService : ILibroService
{
    private readonly List<Libro> _libros =
    [
        new Libro { Id = 1, Titulo = "Cien Años de Soledad", Autor = "Gabriel García Márquez", Imagen = "imagenes/libro1.jpg", AñoPublicacion = 1967 }
    ];

    public List<Libro> ObtenerTodos() => _libros;

    public Libro? ObtenerPorId(int id) => _libros.FirstOrDefault(l => l.Id == id);

    public void Agregar(Libro libro)
    {
        libro.Id = _libros.Max(l => l.Id) + 1;
        _libros.Add(libro);
    }

    public void Actualizar(Libro libro)
    {
        var index = _libros.FindIndex(l => l.Id == libro.Id);
        if (index >= 0) _libros[index] = libro;
    }

    public void Eliminar(int id) => _libros.RemoveAll(l => l.Id == id);
}
