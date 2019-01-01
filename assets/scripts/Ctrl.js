var Ui = require("Ui");
cc.Class({
    extends: cc.Component,

    properties: {
        UI: Ui,
    },

    // LIFE-CYCLE CALLBACKS:

    onLoad () {
        this.isDisplay = false;
    },

    start () {
        this.addEvents();
    },

    onMouseEnter(event){
        if(event.getButton() != cc.Event.EventMouse.BUTTON_RIGHT)return;
        this.isDisplay = !this.isDisplay;
        if(this.isDisplay){
            this.UI.display();
        }
        else{
            this.UI.hide();
        }
    },

    addEvents(){
        this.node.on(cc.Node.EventType.MOUSE_DOWN, this.onMouseEnter, this);
    },
    removeEvents(){
        this.node.off(cc.Node.EventType.MOUSE_DOWN, this.onMouseEnter, this);
    },

    onDestory(){
        this.removeEvents();
    }

    // update (dt) {},
});
