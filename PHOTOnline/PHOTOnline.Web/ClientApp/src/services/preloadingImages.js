export function preloadImages(images) {
    let preloadedImages = [];
    images.forEach((image, index) => {
        preloadedImages[index] = {
            small: new Image(),
            thumbnail: new Image(),
            original: new Image()
        };
        preloadedImages[index].small.src = image.Small.Url;
        preloadedImages[index].thumbnail.src = image.Thumbnail.Url;
        preloadedImages[index].original.src = image.Original.Url;
    });
}

export function preloadAlbums(albums) {
    let preloadedImages = [];
    albums.forEach((album, albumIndex) => {
        album.Images.forEach((image, imageIndex) => {
            preloadedImages[albumIndex * imageIndex + imageIndex] = {
                small: new Image(),
                thumbnail: new Image(),
                original: new Image()
            };
            preloadedImages[albumIndex * imageIndex + imageIndex].small.src = image.Small.Url;
            preloadedImages[albumIndex * imageIndex + imageIndex].thumbnail.src = image.Thumbnail.Url;
            preloadedImages[albumIndex * imageIndex + imageIndex].original.src = image.Original.Url;
        })
    });
}

export function preloadImage(image) {
    let preloadedImage = {
        small: new Image(),
        thumbnail: new Image(),
        original: new Image()
    };

    preloadedImage.small.src = image.Small.Url;
    preloadedImage.thumbnail.src = image.Thumbnail.Url;
    preloadedImage.original.src = image.Original.Url;

    return preloadedImage;
}