// /Scripts/TitleText.jsx
var TitleText = React.createClass({
    render: function() {
        return (
            <div>
                <h1>
                    <span dangerouslySetInnerHTML={{__html: this.props.title}}></span>
                </h1>
                <div dangerouslySetInnerHTML={{__html: this.props.text}} className='contentDescription'></div>
            </div>
        );
    }
});