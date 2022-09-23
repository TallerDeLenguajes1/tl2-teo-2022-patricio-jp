public class Persona {
    public string Nombre;
    public string Apellido;
    public string DNI;
    public DateTime FechaNacimiento;

    public Persona(string nombre, string apellido, string dni, DateTime fechaNac) {
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.DNI = dni;
        this.FechaNacimiento = fechaNac;
    }
}