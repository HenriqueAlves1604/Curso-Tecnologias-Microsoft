namespace JewelCollector;

public class Obstacle
{
    private string tipo {get; set;}
    private Tuple<int, int> posicao {get; set;}

    Obstacle(string tipo, Tuple<int, int> posicao){
        this.tipo = tipo;
        this.posicao = posicao;
    }

}
