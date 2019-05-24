export function getCredentials() {
    return {
        accessToken: localStorage.getItem('accessToken'),
    }
}
export function setCredentials(accessToken) {
    localStorage.setItem('accessToken', accessToken)
}