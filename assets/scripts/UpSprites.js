
cc.Class({
    extends: cc.Component,

    properties: {
        Dishu: {
            default: [],
            type: [cc.Button],
        },
    },

    // LIFE-CYCLE CALLBACKS:

    onLoad () {
        this.curr = 0;
        this.begin = 100;
        this.continued = 130;
        this.index = 0;
        this.play = false;
        this.isDisplay = false;
    },
    
    start () {
        // this.addEvents();
    },

    random(){
        this.index = parseInt(Math.random()*(8+1),10);
        this.display();
    },
    display(){
        this.Dishu[this.index].node.getComponent(cc.Button).interactable = true;
        this.Dishu[this.index].node.getComponent(cc.Sprite).enabled = true;
    },
    hide(){
        this.Dishu[this.index].node.getComponent(cc.Button).interactable = false;
        this.Dishu[this.index].node.getComponent(cc.Sprite).enabled = false;
    },

    dishuClick(object){
        this.node.destroy();
    },

    update (dt) {
        this.updateToCurr();
    },
    updateToCurr(){
        if(!this.play && !this.isDisplay)return;
        if(this.curr == this.begin){
            this.isDisplay = true;
            this.random();
        }
        else if(this.curr == this.continued){
            this.isDisplay = false;
            this.hide();
            this.curr = 99;
        }
        this.curr++;
    },

    onMouseEnter(){
        if(!this.isDisplay){
            this.curr = 0;
        }
        this.play = true;
    },
    onMouseLeave(){
        this.play = false;
    }
   
});
