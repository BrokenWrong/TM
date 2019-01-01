cc.Class({
    extends: cc.Component,

    properties: {
        BTN: {
            // 重来 音乐 CG 菜单 图一 图二 图三 左移 右移
            default: [],
            type: [cc.Button],
        },
    },

    // LIFE-CYCLE CALLBACKS:

    // onLoad () {},

    start () {
        this.hide();
    },

    hide(){
        for (let i = 0; i < this.BTN.length; i++) {
            this.BTN[i].node.active = false;
        }
    },

    display(){
        for (let i = 0; i < this.BTN.length; i++) {
            this.BTN[i].node.active = true;
        }
    }

    // update (dt) {},
});
