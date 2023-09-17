import { AppBar, Box, Button, Toolbar } from '@mui/material'
import React from 'react'

const Header: React.FC = () => {
    return (
        <Box>
            <AppBar position='static'>
                <Toolbar className='header'>
                    <Box>
                        <Button variant='contained' sx={{ color:'white' }}>
                            Home
                        </Button>
                    </Box>
                </Toolbar>
            </AppBar>
        </Box>
    )
}

export default Header