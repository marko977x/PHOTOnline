export function setPageShown(page){
    sessionStorage.setItem('page', page)
}
export function getPageToShow(){
  return{
    page : sessionStorage.getItem('page')
  }
}
export function clearPageShown(){
  sessionStorage.removeItem('page')
}
export function setUserInfo(userID, userType){
  localStorage.setItem('userID', userID),
  localStorage.setItem('userType', userType)
}
export function getUserInfo(){
  return{
    userID: localStorage.getItem('userID'),
    userType: localStorage.getItem('userType')
  }
}
export function clearUserInfo(){
  localStorage.removeItem('userID'),
  localStorage.removeItem('userType')
}
export function setFormMode(formMode){
  sessionStorage.setItem('formMode', formMode)
}
export function getFormMode(){
  return{
    formMode : sessionStorage.getItem('formMode')
  }
}
export function clearFormMode(){
  sessionStorage.removeItem('formMode')
}

export function setOpenedAlbumId(albumId) {
  sessionStorage.setItem('AlbumId', albumId);
}

export function setAlbumKorisnikState(state) {
  console.log(state);
  localStorage.setItem('AlbumKorisnikState', JSON.stringify(state));
}

export function getAlbumKorisnikState() {
  console.log(localStorage);
  return JSON.parse(localStorage.getItem('AlbumKorisnikState'));
}

export function clearSessionStorage() {
  sessionStorage.clear();
}

export function clearLocalStorage() {
  localStorage.clear();
}