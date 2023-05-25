namespace JewelCollector;

public class Jewel {
    private string tipo {get; set;}
    private Tuple<int, int> posicao {get; set;}
    private int valor {get; set;}

    //Construtor:
    public Jewel(string tipo, Tuple<int, int> posicao){
        this.tipo = tipo;
        this.posicao = posicao;
        switch(tipo){
            case "Red":
                this.valor = 100;
                break;
            case "Green":
                this.valor = 50;
                break;
            case "Blue":
                this.valor = 10;
                break;
            default:
                break;
        }
    }

    






}
