var HelloWorld = React.createClass({
    render: function() {
        return (
            <div>
                <h1>
                    Rendering <span>{this.props.title}</span> from React!
                </h1>
            </div>
        );
    }
});