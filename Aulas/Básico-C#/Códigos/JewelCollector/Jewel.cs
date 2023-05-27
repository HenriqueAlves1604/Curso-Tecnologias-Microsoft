namespace JewelCollector;

public class Jewel : Item{
    private string type;
    private int xPosition;
    private int yPosition;
    private int value;

    //Constructor:
    public Jewel(string type, int xPosition, int yPosition) : base("J" + type[0]) {
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

    //Gets and sets:

    public string getType() {
        return this.type;
    }

    public void setType(string type){
        this.type = type;
    }

    public int getXPosition() {
        return this.xPosition;
    }

    public void setXPosition(int xPosition){
        this.xPosition = xPosition;
    }

    public int getYPosition() {
        return this.yPosition;
    }

    public void setYPosition(int yPosition){
        this.yPosition = yPosition;
    }

    public int getValue() {
        return this.value;
    }

    public void setValue(int value){
        this.value = value;
    }


}
