use std::io;
use std::f64::consts::PI;

macro_rules! parse_input {
    ($x:expr, $t:ident) => ($x.trim().parse::<$t>().unwrap())
}

// Function to switch degrees to radian
fn to_radian(x : f64) -> f64{
    x*PI/180.00
}

// Function distance
fn distance(lon : f64, lat : f64, _lon : f64, _lat : f64) -> f64 {
    let x = (_lon - lon)*((lat + _lat)/2.0).cos();
    let y = _lat - lat;
    return (f64::powf(x,2.0) + f64::powf(y, 2.0)).sqrt()*6371.0 ;
}

// Main function
fn main() {
    // Set Longitude
    let mut input_line = String::new();
    dbg!(&io::stdin().read_line(&mut input_line).unwrap());
    let lon = to_radian(input_line.trim().to_string().replace(",", ".").parse::<f64>().unwrap());
    
    // Set Latitude
    let mut input_line = String::new();
    io::stdin().read_line(&mut input_line).unwrap();
    let lat = to_radian(input_line.trim().to_string().replace(",", ".").parse::<f64>().unwrap());

    // IDK
    let mut input_line = String::new();
    io::stdin().read_line(&mut input_line).unwrap();

    // Nombre de défibrillateurs
    let n = parse_input!(input_line, i32);

    // Distance most close
    let mut dist : f64 = 360.0;
    
    // Name of defib most close
    let mut name : String = String::new();


    for i in 0..n as usize {
        let mut input_line = String::new();
        io::stdin().read_line(&mut input_line).unwrap();
        let defib = input_line.trim_matches('\n').split(';').collect::<Vec<&str>>();

        let _lon: f64 = to_radian(defib[4].replace(",", ".").parse::<f64>().unwrap());
        let _lat: f64 = to_radian(defib[5].replace(",", ".").parse::<f64>().unwrap());
        let _name: String = defib[1].to_string();
        let tmp = distance(lon, lat, _lon, _lat);
        if i == 0 { name = _name.clone(); }
        if tmp < dist {
            dist = tmp;
            name = _name.clone();
        }
    }
    println!("{}", name);


}
