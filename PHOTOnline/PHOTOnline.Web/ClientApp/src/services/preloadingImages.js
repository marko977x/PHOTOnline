export function preloadImages(images) {
    let preloadedImages = [];
    images.forEach((image, index) => {
        preloadedImages[index] = {
            small: new Image(),
            thumbnail: new Image(),
            orginal: new Image()
        };
        this.preloadedImages[index].small.src = image.Small.Url;
        this.preloadedImages[index].thumbnail.src = image.Thumbnail.Url;
        this.preloadedImages[index].original.src = image.Original.Url;
    });
}

export function preloadAlbums(albums) {
    let preloadedImages = [];
    albums.forEach((album, albumIndex) => {
        album.Images.forEach((image, imageIndex) => {
            preloadedImages[albumIndex * imageIndex + imageIndex] = {
                small: new Image(),
                thumbnail: new Image(),
                orginal: new Image()
            };
            this.preloadedImages[albumIndex * imageIndex + imageIndex].small.src = image.Small.Url;
            this.preloadedImages[albumIndex * imageIndex + imageIndex].thumbnail.src = image.Thumbnail.Url;
            this.preloadedImages[albumIndex * imageIndex + imageIndex].original.src = image.Original.Url;
        })
    });
}