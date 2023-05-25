namespace JewelCollector;

public class Jewel {
    private string type {get; set;}
    private int xPosition {get; set;}
    private int yPosition {get; set;}
    private int value {get; set;}

    //Construtor:
    public Jewel(string type, int xPosition, int yPosition){
        this.type = type;
        this.xPosition = xPosition;
        this.yPosition = yPosition;
        switch(type){
            case "Red":
                this.value = 100;
                break;
            case "Green":
                this.value = 50;
                break;
            case "Blue":
                this.value = 10;
                break;
            default:
                break;
        }
    }








}
