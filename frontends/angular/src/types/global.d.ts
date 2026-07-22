export {};

declare global {
    let isLoggedIn: boolean;

    function editStatus(isLoggedIn: boolean) : boolean;
}