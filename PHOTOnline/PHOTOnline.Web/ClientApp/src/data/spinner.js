import { vue } from "../main";

let spinner;

export function openSpinner() {
    spinner = vue.$loading({
        text: 'Loading',
        spinner: 'el-icon-loading',
        background: 'rgba(0, 0, 0, 0.75)'
    });
}

export function closeSpinner() {
    spinner.close();
}

