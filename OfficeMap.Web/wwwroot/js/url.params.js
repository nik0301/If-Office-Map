const URLParams = function(href) {
    var parameters = {};
    const delimiter = ",";
    var fullPathname = "";

    /* Returns array with two values - full pathname, get parameters */
    const getHrefParts = function (href) {
        var parts = {};
        const index = href.indexOf('?');

        if (index >= 0) {
            parts["pathname"] = href.split('?')[0];
            parts["parameters"] = href.split('?')[1].split(/&+/);
        } else {
            parts["pathname"] = href;
            parts["parameters"] = [];
        }
        return parts;
    };

    /* Initializes path and parameters from href */
    const init = function(href) {
        const parts = getHrefParts(href);
        fullPathname = parts["pathname"];

        for (let key in parts["parameters"]) {
            const value = parts["parameters"][key];
            const index = value.indexOf('=');

            if (index > -1) {
                parameters[value.slice(0, index)] = decodeURIComponent(value.slice(index + 1));
            }
        }
    };

    /* Sets url parameter */
    const set = function(name, value) {
        parameters[name] = value;
    };

    /* Returns parameters object: {param1: "value", param2: "value", ..} */
    const get = function() {
        return parameters;
    };

    /* Returns true if has parameter */
    const has = function (name) {
        return parameters[name] !== undefined;
    };

    /* Returns array of parameter values: ["val1", "val2", ..] */
    const values = function (name) {
        var values = [];

        if (has(name)) {
            values = decodeURIComponent(parameters[name]).split(delimiter);
        }

        return values;
    };

    /* Returns true if has parameter and parameter has value */
    const hasValue = function (name, value) {
        return has(name) && values(name).indexOf(value) > -1;
    };

    /* Sets parameter value appending new value ("val1,..,new_val").
       Sets parameter if even parameter not set yet.
    */
    const append = function(name, value) {
        if (!hasValue(name, value)) {
            const newValues = values(name);
            newValues.push(value);
            set(name, newValues.join(delimiter));
            return true;
        }
        return false;
    };

    /* Returns first parameter value if parameter exists */
    const first = function(name) {
        const values = values(name);
        if (values.length > 0) {
            return values[0];
        }
        return null;
    };

    /* Returns array of parameters names: ["param1", "param2", ..] */
    const keys = function() {
        var keys = [];

        for (let key in parameters) {
            keys.push(key);
        }

        return keys;
    };

    /* Removes parameter */
    const removeKey = function (name) {
        delete parameters[name];
    };

    /* Removes parameter value from values.
       Example:
        Before:         param: "val1,val2,val3"
        Remove "val2":  param: "val1,val3"

       After value removed, if parameter has no value then remove parameter.
    */
    const remove = function(name, value) {
        if (hasValue(name, value)) {
            var newValues = values(name);
            const index = newValues.indexOf(value);

            newValues.splice(index, 1);
            set(name, newValues.join(delimiter));

            // remove parameter if no value
            if (newValues.length === 0) {
                removeKey(name);
            }
        }
    };

    /* Sets parameter value appending/removing value.
       If value exists then remove or if not exists then append.
    */
    const toggle = function(name, value) {
        if (hasValue(name, value)) {
            remove(name, value);
            return false;
        } else {
            append(name, value);
            return true;
        }
    };

    /* Returns string of get parameters */
    const toString = function() {
        var pairs = [];

        for (let key in parameters) {
            pairs.push(key + '=' + parameters[key]);
        }

        return pairs.join('&');
    };

    /* Returns string of get parameters for url */
    const toUrlString = function () {
        var pairs = [];

        for (let key in parameters) {
            pairs.push(key + '=' + encodeURIComponent(parameters[key]));
        }

        return pairs.join('&');
    };

    /* Changes browser url replacing get params */
    const replaceBrowserUrl = function() {
        const params = toUrlString();
        var newUrl = fullPathname;

        if (params.length > 0) {
            newUrl += "?" + params;
        }

        history.pushState({}, null, newUrl);
    };

    // This executes immediately
    init(href);

    // The only events and data available outside this function
    return {
        init: init,
        set: set,
        get: get,
        has: has,
        values: values,
        hasValue: hasValue,
        append: append,
        first: first,
        keys: keys,
        removeKey: removeKey,
        remove: remove,
        toggle: toggle,
        toString: toString,
        replaceBrowserUrl: replaceBrowserUrl
    };
};
