import { LINKS_LOADED, PAGE_CHANGED } from '../actions/links.actions'

const links = (state, action) => {
    if (state == undefined) {
        state = {
            links: [],
            pagesLimit: 1,
            currentPage: 1
        }
    }

    switch (action.type) {
        case LINKS_LOADED:
            return { ...action.payload };
        case PAGE_CHANGED:
            return Object.assign({}, state, { currentPage: action.payload.pageNumber });
        default:
            return state;
    }
}

export default links;