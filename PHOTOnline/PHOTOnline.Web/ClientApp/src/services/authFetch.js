export const destinationUrl = 'https://localhost:5001'
export function getCredentials() {
    return {
        accessToken: localStorage.getItem('accessToken'),
    }
}
export function setCredentials(accessToken) {
    localStorage.setItem('accessToken', accessToken)
}
export function deleteCredentials()
{
    localStorage.removeItem('accessToken')
}
export function apiFetchFactory({getCredentials, deleteCredentials, setCredentials, fetch}) {
    return async function apiFetch(method, url, {
        contentType = 'application/json',
        hasAuthHeader = true,
        responseType = 'json'
    } = {}, body) {
        // isReachable('192.168.137.105:8080').then(r => console.log("reachable ", r))
        const {accessToken} = getCredentials()
        const res = await fetch(url, {
            method: method,
            body: JSON.stringify(body),
            headers: {
                ...(hasAuthHeader ? {'authorization': accessToken} : {}),
            }
        })
        if (responseType == "json" && res.status >= 200 && res.status < 300)
            return res.json()
        else
            return res.status.toString()
    }
}

export const apiFetch = apiFetchFactory({getCredentials, setCredentials, deleteCredentials, fetch})