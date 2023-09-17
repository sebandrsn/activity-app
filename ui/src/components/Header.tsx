import { AppBar, Box, Button, Toolbar } from '@mui/material'
import React from 'react'
import { useNavigate } from 'react-router-dom'

const Header: React.FC = () => {
    const navigate = useNavigate()

    return (
        <Box>
            <AppBar position='static'>
                <Toolbar className='header'>
                    <Box>
                        <Button variant='contained' sx={{ color:'white' }} onClick={() => {navigate('/')}}>
                            Home
                        </Button>
                    </Box>
                </Toolbar>
            </AppBar>
        </Box>
    )
}

export default Header