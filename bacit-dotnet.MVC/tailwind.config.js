module.exports = {
    mode: "jit",
    content: [
        './Pages/**/*.cshtml',
        './Views/**/*.cshtml'
    ],
    theme: {
        extend: {
            margin: {
                '100': '25rem', // This adds a custom margin class "ml-100" with a value of 25rem
                '200': '50rem', // You can add more custom margin classes as needed
            },
            colors: {
                transparent: 'transparent',
                current: 'currentColor',
                'white': '#ffffff',
                'purple': '#3f3cbb',
                'orange': '#f97316',
                'metal': '#565584',
                'tahiti': '#3ab7bf',
                'silver': '#ecebff',
                'bubble-gum': '#ff77e9',
                'bermuda': '#78dcca',
            }
         },
        plugins: [
            require('flowbite/plugin')

        ],
        content: [
            "./node_modules/flowbite/**/*.js"
        ],

    }
}
