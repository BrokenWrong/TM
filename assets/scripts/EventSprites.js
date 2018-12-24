
cc.Class({
    extends: cc.Component,

    properties: {
    },

    // LIFE-CYCLE CALLBACKS:

    onLoad () {
        this.upSprites = this.node.getParent().getComponent('UpSprites');
    },

    start () {
        this.addEvents();
    },

    onMouseEnter(event){
        this.upSprites.onMouseEnter();
    },
    onMouseLeave(event){
        this.upSprites.onMouseLeave();
    },

    addEvents(){
        this.node.on(cc.Node.EventType.MOUSE_ENTER, this.onMouseEnter, this);
        this.node.on(cc.Node.EventType.MOUSE_LEAVE, this.onMouseLeave, this);
    },
    removeEvents(){
        this.node.off(cc.Node.EventType.MOUSE_ENTER, this.onMouseEnter, this);
        this.node.off(cc.Node.EventType.MOUSE_LEAVE, this.onMouseLeave, this);
    },

    onDestory(){
        this.removeEvents();
    }

    // update (dt) {},
});
