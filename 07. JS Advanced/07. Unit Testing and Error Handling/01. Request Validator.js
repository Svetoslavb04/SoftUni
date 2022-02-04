function validateHTTPRequset(httpObj) { 
    let method = httpObj.method;
    let uri = httpObj.uri;
    let version = httpObj.version;
    let message = httpObj.message;

    if (!httpObj.hasOwnProperty('method') || method != 'GET' && method != 'POST' && method != 'DELETE' && method != 'CONNECT') {
        throw new Error('Invalid request header: Invalid Method');
    }

    let uriRegex = /^([\w\d\.]+|\*)$/g;
    if (!httpObj.hasOwnProperty('uri') || !uri.match(uriRegex)){
        throw new Error('Invalid request header: Invalid URI');
    }

    if (!httpObj.hasOwnProperty('version') || version != 'HTTP/0.9' && version != 'HTTP/1.0' && version != 'HTTP/1.1' && version != 'HTTP/2.0') {
        throw new Error('Invalid request header: Invalid Version');
    }

    let messageRegex = /^([^<>\\&'"]*)$/g;
    if (!httpObj.hasOwnProperty('message') || !message.match(messageRegex)) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return httpObj;
}