export const destinationUrl = 'https://localhost:5001/api'
export function getCredentials() {
    return {
        accessToken: localStorage.getItem('accessToken'),
    }
}
export function setCredentials(accessToken) {
    localStorage.setItem('accessToken', accessToken)
}
export function deleteCredentials() {
    localStorage.removeItem('accessToken')
}
export function apiFetchFactory() {
    return async function apiFetch(method, url, body) {
        const formData = new FormData();
        for (let key in body) {
            formData.append(key,body[key]);
        }
        let result = null;
        if (body == null) {
            result = await fetch(url, {
                method: method
            });
        } else {
            result = await fetch(url, {
                method: method,
                body: formData
            });
        }

        return result.json();
    }
}

export const apiFetch = apiFetchFactory();

export const REGULAR_USER_TYPE = 0;
export const PHOTOGRAPH_USER_TYPE = 1;
export const ADMIN_USER_TYPE = 2;
export const ANONYMOUS_USER_TYPE = 3;

export const UserTypes = ["Korisnik", "Fotograf", "Uprava", "Anonimni"];