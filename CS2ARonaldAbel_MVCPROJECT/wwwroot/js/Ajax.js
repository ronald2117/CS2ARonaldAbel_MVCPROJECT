const AjaxGET = async (url) => {
    return await $.ajax({
        url: url,
        type: "Get",
    });
}

const AjaxPOST = async (url, data) => {
    return await $.ajax({
        url: url,
        type: "Post",
        data: data
    });
}