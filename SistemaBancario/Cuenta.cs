public enum TipoExtraccion {
    CajeroHumano = 1,
    CajeroAutomatico = 2
}

public class Cuenta {
    protected Persona Titular;
    protected int Saldo;
    protected DateTime UltimaExtraccion;
    protected DateTime UltimaInsercion;

    public virtual void Insercion(int monto) {
        Console.WriteLine("=== Inserción ===");
        Console.WriteLine($"Saldo anterior: ${this.Saldo}");
        this.Saldo += monto;
        Console.WriteLine($"Nuevo saldo: ${this.Saldo}");
    }

    public virtual void Extraccion(int monto, TipoExtraccion tipo) {
        if (monto <= this.Saldo) {
            this.Saldo -= monto;
            Console.WriteLine($"Nuevo saldo: ${this.Saldo}");
        } else {
            Console.WriteLine("No se puede extraer la cantidad solicitada.");
        }
    }

    public Cuenta(string nombre, string apellido, string DNI, DateTime fechaNac) {
        this.Titular = new Persona(nombre, apellido, DNI, fechaNac);
        this.Saldo = 0;
        this.UltimaInsercion = new DateTime();
        this.UltimaExtraccion = new DateTime();
    }
}

public class CtaCtePesos : Cuenta {
    public override void Extraccion(int monto, TipoExtraccion tipo) {
        if (monto > (this.Saldo + 5000)) {
            Console.WriteLine("[AVISO]: Se intenta extraer una cantidad mayor a su saldo actual.");
        } else {
            if (tipo == TipoExtraccion.CajeroAutomatico && monto > 20000) {
                Console.WriteLine("No se puede extraer la cantidad solicitada.");
            } else {
                Console.WriteLine("=== Extracción ===");
                Console.WriteLine($"Saldo anterior: ${this.Saldo}");
                this.Saldo -= monto;
                Console.WriteLine($"Nuevo saldo: ${this.Saldo}");
            }
        }
    }

    public CtaCtePesos(string nombre, string apellido, string DNI, DateTime fechaNac) : base(nombre, apellido, DNI, fechaNac) {}
}

public class CtaCteDolares : Cuenta {
    public override void Extraccion(int monto, TipoExtraccion tipo) {
        if (tipo == TipoExtraccion.CajeroAutomatico) {
            if (monto > 200 || this.UltimaExtraccion.Date == DateTime.Today.Date) {
                Console.WriteLine("No se puede extraer más de 200 U$D por día");
            } else {
                Console.WriteLine("=== Extracción ===");
                Console.WriteLine($"Saldo anterior: U$D {this.Saldo}");
                this.Saldo -= monto;
                Console.WriteLine($"Nuevo saldo: U$D {this.Saldo}");
            }
        }
    }

    public CtaCteDolares(string nombre, string apellido, string DNI, DateTime fechaNac) : base(nombre, apellido, DNI, fechaNac) {}
}

public class CtaAhorroPesos : Cuenta {
    public override void Extraccion(int monto, TipoExtraccion tipo) {
        if (monto > this.Saldo) {
            Console.WriteLine("No se puede extraer la cantidad solicitada.");
        } else {
            if (tipo == TipoExtraccion.CajeroAutomatico && monto > 10000) {
                Console.WriteLine("No se puede extraer la cantidad solicitada mediante cajero automático.");
            } else {
                Console.WriteLine("=== Extracción ===");
                Console.WriteLine($"Saldo anterior: ${this.Saldo}");
                this.Saldo -= monto;
                Console.WriteLine($"Nuevo saldo: ${this.Saldo}");
            }
        }
    }

    public CtaAhorroPesos(string nombre, string apellido, string DNI, DateTime fechaNac) : base(nombre, apellido, DNI, fechaNac) {}
}
