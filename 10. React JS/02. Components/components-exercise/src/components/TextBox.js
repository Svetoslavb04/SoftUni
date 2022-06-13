export const TextBox = (props) => {
    if (props.disabled) {
        return(
            <div>
                <label htmlFor={props.name}>{props.name}</label>
                <input name={props.name} placeholder={props.children} disabled/>
            </div>
        );
    }

    return(
        <div>
            <label htmlFor={props.name}>{props.name}</label>
            <input name={props.name} placeholder={props.children} onBlur={props.onChange}/>
        </div>
    );
}