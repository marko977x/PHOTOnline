import { Vue } from "vue";

export function openSpinner() {
    return Vue.$loading({
        text: 'Loading',
        spinner: 'el-icon-loading',
        background: 'rgba(0, 0, 0, 0.75)'
    });
}